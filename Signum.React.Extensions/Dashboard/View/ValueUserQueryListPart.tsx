﻿
import * as React from 'react'
import { FormGroup, FormControlReadonly, ValueLine, ValueLineType, EntityLine, EntityCombo, EntityList, EntityRepeater, RenderEntity} from '@framework/Lines'
import * as Finder from '@framework/Finder'
import { QueryDescription, SubTokensOptions, FindOptions } from '@framework/FindOptions'
import { getQueryNiceName, PropertyRoute, getTypeInfos } from '@framework/Reflection'
import { ModifiableEntity, EntityControlMessage, Entity, parseLite, getToString, Lite, is, JavascriptMessage } from '@framework/Signum.Entities'
import * as Navigator from '@framework/Navigator'
import * as Constructor from '@framework/Constructor'
import { ValueSearchControlLine } from '@framework/Search'
import { TypeContext, FormGroupStyle, mlistItemContext } from '@framework/TypeContext'
import QueryTokenEntityBuilder from '../../UserAssets/Templates/QueryTokenEntityBuilder'
import * as UserQueryClient from '../../UserQueries/UserQueryClient'
import { ValueUserQueryListPartEntity, ValueUserQueryElementEmbedded } from '../Signum.Entities.Dashboard'

export default class ValueUserQueryListPart extends React.Component<{ part: ValueUserQueryListPartEntity; entity?: Lite<Entity> }> {
    
    render() {

        const entity = this.props.part;
        const ctx = TypeContext.root(entity, { formGroupStyle: "None" });
        return (
            <div>
                {
                    mlistItemContext(ctx.subCtx(a => a.userQueries))
                        .map((ctx, i) =>                             
                            <div key={i} >    
                                <ValueUserQueryElement ctx={ctx} entity={this.props.entity}/>    
                            </div>)
                }
            </div>
        );
    }
}

export interface ValueUserQueryElementProps {
    ctx: TypeContext<ValueUserQueryElementEmbedded>
    entity?: Lite<Entity>; 
}

export class ValueUserQueryElement extends React.Component<ValueUserQueryElementProps, {fo?: FindOptions }> {
    
    state = { fo: undefined } as { fo?: FindOptions };

    componentWillMount(){
        this.loadFindOptions(this.props);
    }

    componentWillReceiveProps(newProps : ValueUserQueryElementProps ){

        if(is(this.props.ctx.value.userQuery, newProps.ctx.value.userQuery))
            return;

        this.loadFindOptions(newProps);
    }

    loadFindOptions(props: ValueUserQueryElementProps) {

        UserQueryClient.Converter.toFindOptions(props.ctx.value.userQuery!, this.props.entity)
            .then(fo => this.setState({ fo: fo }))
            .done();
    }

    render(){

        const ctx = this.props.ctx;
        const ctx2 = ctx.subCtx({ formGroupStyle: "SrOnly" });

        if (!this.state.fo)
            return <span>{ JavascriptMessage.loading.niceToString() }</span>;

        return (
            <div>
                <FormGroup ctx={ctx} labelText={ctx.value.label || getQueryNiceName(this.state.fo.queryName)}>
                    <span className="form-inline">
                        <span>{ctx.value.label || getQueryNiceName(this.state.fo.queryName)}</span>&nbsp;
                        <ValueSearchControlLine ctx={ctx2} findOptions={this.state.fo} />
                    </span>
                </FormGroup>
            </div>             
        );
    }   
} 



