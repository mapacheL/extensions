﻿import * as React from 'react'
import { Tabs, Tab } from 'react-bootstrap';
import * as numbro from 'numbro';
import { classes } from '../../../../Framework/Signum.React/Scripts/Globals'
import { FormGroup, FormControlStatic, ValueLine, ValueLineType, EntityLine, EntityDetail, EntityCombo, EntityList, EntityRepeater, EntityTable, IRenderButtons, EntityTabRepeater } from '../../../../Framework/Signum.React/Scripts/Lines'
import { SearchControl } from '../../../../Framework/Signum.React/Scripts/Search'
import { TypeContext, FormGroupStyle, ButtonsContext } from '../../../../Framework/Signum.React/Scripts/TypeContext'
import FileLine from '../../Files/FileLine'
import { PredictorEntity, PredictorColumnEmbedded, PredictorMessage, PredictorSubQueryEntity, PredictorGroupKeyEmbedded, PredictorFileType, PredictorCodificationEntity } from '../Signum.Entities.MachineLearning'
import * as Finder from '../../../../Framework/Signum.React/Scripts/Finder'
import * as Navigator from '../../../../Framework/Signum.React/Scripts/Navigator'
import { getQueryNiceName } from '../../../../Framework/Signum.React/Scripts/Reflection'
import QueryTokenEntityBuilder from '../../UserAssets/Templates/QueryTokenEntityBuilder'
import { QueryFilterEmbedded } from '../../UserQueries/Signum.Entities.UserQueries'
import { QueryDescription, SubTokensOptions } from '../../../../Framework/Signum.React/Scripts/FindOptions'
import * as PredictorClient from '../PredictorClient';
import { toLite } from "../../../../Framework/Signum.React/Scripts/Signum.Entities";
import FilterBuilder from '../../../../Framework/Signum.React/Scripts/SearchControl/FilterBuilder';
import { MList, newMListElement } from '../../../../Framework/Signum.React/Scripts/Signum.Entities';
import FilterBuilderEmbedded from './FilterBuilderEmbedded';
import PredictorSubQuery from './PredictorSubQuery';
import { QueryTokenEmbedded } from '../../UserAssets/Signum.Entities.UserAssets';
import { QueryEntity } from '../../../../Framework/Signum.React/Scripts/Signum.Entities.Basics';
import { FilePathEmbedded } from '../../Files/Signum.Entities.Files';
import { is } from '../../../../Framework/Signum.React/Scripts/Signum.Entities';
import { BsStyle } from '../../../../Framework/Signum.React/Scripts/Operations';

export default class Predictor extends React.Component<{ ctx: TypeContext<PredictorEntity> }, { queryDescription?: QueryDescription }> {

    constructor(props: any) {
        super(props);
        this.state = { queryDescription: undefined };
    }

    componentWillMount() {

        let p = this.props.ctx.value;
        if (p.mainQuery.query)
            this.loadData(p.mainQuery.query);
    }

    loadData(query: QueryEntity) {
        Finder.getQueryDescription(query.key)
            .then(qd => this.setState({ queryDescription: qd }))
            .done();
    }


    handleQueryChange = () => {

        const p = this.props.ctx.value;
        p.mainQuery.filters = [];
        p.mainQuery.columns = [];
        p.subQueries = [];
        this.forceUpdate();

        this.setState({
            queryDescription: undefined
        }, () => {
            if (p.mainQuery.query)
                this.loadData(p.mainQuery.query);
        });
    }

    handleCreate = () => {

        var query = this.props.ctx.value.mainQuery.query;
        return Finder.parseSingleToken(query!.key, "Entity", SubTokensOptions.CanElement)
            .then(qt => PredictorSubQueryEntity.New({
                query: query,
                groupKeys: [
                    newMListElement(PredictorGroupKeyEmbedded.New({
                        token: QueryTokenEmbedded.New({
                            token: qt,
                            tokenString: "Entity",
                        })
                    }))
                ]
            }));
    }

    handleAlgorithmChange = () => {
        var pred = this.props.ctx.value;
        var al = pred.algorithm;
        if (al == null)
            pred.algorithmSettings = null;
        else {
            var init = PredictorClient.initializers[al.key];

            if (init != null)
                init(pred);
        }

        this.forceUpdate();
    }

    handleOnFinished = () => {
        const ctx = this.props.ctx;
        Navigator.API.fetchEntityPack(toLite(ctx.value))
            .then(pack => ctx.frame!.onReload(pack))
            .done();
    }

    render() {
        let ctx = this.props.ctx;

        if (ctx.value.state != "Draft")
            ctx = ctx.subCtx({ readOnly: true });

        const ctxxs = ctx.subCtx({ formGroupSize: "ExtraSmall" });
        const ctxmq = ctxxs.subCtx(a => a.mainQuery);
        const entity = ctx.value;
        const queryKey = entity.mainQuery.query && entity.mainQuery.query.key;

        return (
            <div>
                <ValueLine ctx={ctxxs.subCtx(e => e.name)} />
                <ValueLine ctx={ctxxs.subCtx(e => e.state, { readOnly: true })} />
                <EntityLine ctx={ctxxs.subCtx(e => e.trainingException, { readOnly: true })} hideIfNull={true} />
                {ctx.value.state == "Training" && <TrainingProgressComponent ctx={ctx} onStateChanged={this.handleOnFinished} />}
                <Tabs id={ctx.prefix + "tabs"}>
                    <Tab eventKey="query" title={ctxmq.niceName(a => a.query)}>
                        <EntityLine ctx={ctxmq.subCtx(f => f.query)} remove={ctx.value.isNew} onChange={this.handleQueryChange} />
                        {queryKey &&
                            <div>
                                <fieldset>
                                    <legend>{ctxmq.niceName()}</legend>
                                    <div>
                                        <FilterBuilderEmbedded ctx={ctxmq.subCtx(a => a.filters)}
                                            queryKey={queryKey}
                                            subTokenOptions={SubTokensOptions.CanAnyAll | SubTokensOptions.CanElement} />
                                        <EntityTable ctx={ctxmq.subCtx(e => e.columns)} columns={EntityTable.typedColumns<PredictorColumnEmbedded>([
                                            { property: a => a.usage },
                                            {
                                                property: a => a.token,
                                                template: ctx => <QueryTokenEntityBuilder
                                                    ctx={ctx.subCtx(a => a.token)}
                                                    queryKey={this.props.ctx.value.mainQuery.query!.key}
                                                    subTokenOptions={SubTokensOptions.CanElement} />,
                                                headerHtmlAttributes: { style: { width: "40%" } },
                                            },
                                            { property: a => a.encoding },
                                        ])} />
                                    </div>
                                </fieldset>
                                <EntityTabRepeater ctx={ctxxs.subCtx(e => e.subQueries)} onCreate={this.handleCreate}
                                    getTitle={(mctx: TypeContext<PredictorSubQueryEntity>) => mctx.value.name || PredictorSubQueryEntity.niceName()}
                                    getComponent={(mctx: TypeContext<PredictorSubQueryEntity>) =>
                                        <div>
                                            {!this.state.queryDescription ? undefined : <PredictorSubQuery ctx={mctx} targetType={this.state.queryDescription.columns["Entity"].type} />}
                                        </div>
                                    } />
                            </div>
                        }
                    </Tab>
                    <Tab eventKey="algorithm" title={ctxxs.niceName(a => a.algorithmSettings)}>
                        <EntityCombo ctx={ctxxs.subCtx(f => f.algorithm)} onChange={this.handleAlgorithmChange} />
                        {ctxxs.value.algorithm && <EntityDetail ctx={ctxxs.subCtx(f => f.algorithmSettings)} remove={false} />}
                        <EntityDetail ctx={ctxxs.subCtx(f => f.settings)} remove={false} />
                    </Tab>
                    {
                        ctx.value.state != "Draft" && <Tab eventKey="codifications" title={PredictorCodificationEntity.nicePluralName()}>
                            <SearchControl findOptions={{ queryName: PredictorCodificationEntity, parentColumn: "Predictor", parentValue: ctx.value }} />
                        </Tab>
                    }
                    {
                        ctx.value.state != "Draft" && <Tab eventKey="files" title={ctxxs.niceName(a => a.files)}>
                            <EntityRepeater ctx={ctxxs.subCtx(f => f.files)} getComponent={ec =>
                                <FileLine ctx={ec.subCtx({ formGroupStyle: "SrOnly" })} remove={false} fileType={PredictorFileType.PredictorFile} />
                            } />
                            <EntityDetail ctx={ctxxs.subCtx(f => f.classificationTraining)} />
                            <EntityDetail ctx={ctxxs.subCtx(f => f.classificationValidation)} />
                            <EntityDetail ctx={ctxxs.subCtx(f => f.regressionTraining)} />
                            <EntityDetail ctx={ctxxs.subCtx(f => f.regressionValidation)} />
                        </Tab>
                    }
                </Tabs>
            </div>
        );
    }
}


interface TrainingProgressComponentProps {
    ctx: TypeContext<PredictorEntity>;
    onStateChanged: () => void;
}

interface TrainingProgressComponentState {
    trainingProgress?: PredictorClient.TrainingProgress | null;
}

export class TrainingProgressComponent extends React.Component<TrainingProgressComponentProps, TrainingProgressComponentState> {

    constructor(props: TrainingProgressComponentProps) {
        super(props);
        this.state = {};
    }

    componentWillMount() {
        this.loadData(this.props);
    }

    componentWillReceiveProps(newProps: TrainingProgressComponentProps) {
        if (!is(newProps.ctx.value, this.props.ctx.value))
            this.loadData(newProps);
    }

    componentWillUnmount() {
        if (this.timeoutHandler)
            clearTimeout(this.timeoutHandler);
    }

    refreshInterval = 500;

    timeoutHandler: number;

    loadData(props: TrainingProgressComponentProps) {
        PredictorClient.API.getTrainingState(toLite(props.ctx.value))
            .then(p => {
                var prev = this.state.trainingProgress;
                this.setState({ trainingProgress: p });
                if (prev != null && prev.State != p.State)
                    this.props.onStateChanged();
                else
                    this.timeoutHandler = setTimeout(() => this.loadData(this.props), this.refreshInterval);
            })
            .done();
    }

    render() {

        const tp = this.state.trainingProgress;

        return (
            <ProgressBar color={tp == null ? "info" : "default"}
                value={tp && tp.Progress}
                message={tp == null ? PredictorMessage.StartingTraining.niceToString() : tp.Message}
            />
        );
    }

}


interface ProgressBarProps {
    value?: number | null; /*0...1*/
    showPercentageInMessage?: boolean | null;
    message?: string | null;
    color?: BsStyle | null;
}

export class ProgressBar extends React.Component<ProgressBarProps> {
    render() {

        const { value, showPercentageInMessage, message, color } = this.props;

        const progressContainerClass = value == null ? "progress-bar-striped active" : "";

        const progressStyle = color == null ? "progress-bar-" + color : "";

        const fullMessage = [
            (value == null || showPercentageInMessage === false ? undefined : `${numbro(value).format("0.00")}%`),
            (message ? message : undefined)
        ].filter(a => a != null).join(" - ");

        return (
            <div className={classes("progress")}>
                <div className={classes("progress-bar", progressStyle, progressContainerClass)} role="progressbar" id="progressBar"
                    aria-valuenow={value == null ? undefined : value * 100}
                    aria-valuemin={value == null ? undefined : 0}
                    aria-valuemax={value == null ? undefined : 100}
                    style={{ width: value == null ? "100%" : (value * 100) + "%" }}>
                    <span style={{ color: (value != null && value < 0.5) ? "black" : undefined }}>{fullMessage}</span>
                </div>
            </div>
        );
    }
}