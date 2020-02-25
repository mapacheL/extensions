import * as React from 'react'
import { ajaxPost, ajaxGet } from '@framework/Services';
import { EntitySettings } from '@framework/Navigator'
import * as Navigator from '@framework/Navigator'
import * as Finder from '@framework/Finder'
import { Entity, Lite, liteKey } from '@framework/Signum.Entities'
import * as QuickLinks from '@framework/QuickLinks'
import { OrderOptionParsed } from '@framework/FindOptions'
import * as AuthClient from '../../Authorization/AuthClient'
import { UserChartEntity, ChartPermission, ChartMessage, ChartRequestModel, ChartParameterEmbedded, ChartColumnEmbedded, ChartPaletteModel } from '../Signum.Entities.Chart'
import { QueryFilterEmbedded, QueryOrderEmbedded } from '../../UserQueries/Signum.Entities.UserQueries'
import { QueryTokenEmbedded } from '../../UserAssets/Signum.Entities.UserAssets'
import * as ChartClient from '../ChartClient'
import * as UserAssetsClient from '../../UserAssets/UserAssetClient'
import { ImportRoute } from "@framework/AsyncImport";
import { OrderRequest } from '@framework/FindOptions';
import { toFilterRequests } from '@framework/Finder';
import { PseudoType, getTypeName, getTypeInfo, tryGetTypeInfo } from '@framework/Reflection';
import { asFieldFunction } from '../../Dynamic/View/NodeUtils';
import MessageModal from '../../../../Framework/Signum.React/Scripts/Modals/MessageModal';

export function start(options: { routes: JSX.Element[] }) {
  Navigator.addSettings(new EntitySettings(ChartPaletteModel, e => import('./ChartPaletteControl')));
}

export function navigatePalette(type: PseudoType): Promise<void> {
  return API.fetchColorPalette(getTypeName(type))
    .then(cp => {
      if (cp == null)
        return MessageModal.showError(ChartMessage.Type0NotFoundInTheDatabase.niceToString(getTypeName(type)), ChartMessage.TypeNotFound.niceToString());

      return Navigator.navigate(cp)
    });
}

export let colorPalettesTypes: string[];
export function getColorPaletteTypes(): Promise<string[]> {
  if (colorPalettesTypes)
    return Promise.resolve(colorPalettesTypes);

  return API.fetchColorPalettes().then(cs => colorPalettesTypes = cs);
}

export interface ColorPalette {
  [id: string]: string;
}

export let colorPalette: { [typeName: string]: ColorPalette | null } = {};
export function getColorPalette(type: PseudoType): Promise<ColorPalette | null> {

  const typeName = getTypeName(type);

  if (colorPalette[typeName])
    return Promise.resolve(colorPalette[typeName]);

  return API.fetchColorPalette(typeName).then(cs => colorPalette[typeName] = cs && toColorPalete(cs));
}

export function toColorPalete(model: ChartPaletteModel): ColorPalette {

  var ti = tryGetTypeInfo(model.type.cleanName);

  var byId = model.colors.filter(a => a.element.color != null)
    .toObject(a => a.element.related.id as string, a => a.element.color); 

  if (ti == null || ti.kind == "Enum") {
    var byName = model.colors.filter(a => a.element.color != null)
      .toObject(a => a.element.related.toStr!, a => a.element.color);  
    return { ...byId, ...byName };
  }

  return byId;
}

export function setColorPalette(model: ChartPaletteModel) {

  if (model.colors.some(c => c.element.color != null)) {
    colorPalette[model.type.cleanName] = toColorPalete(model);
    if (!colorPalettesTypes.contains(model.type.cleanName))
      colorPalettesTypes.push(model.type.cleanName);
  } else {
    delete colorPalette[model.type.cleanName];
    if (colorPalettesTypes.contains(model.type.cleanName))
      colorPalettesTypes.remove(model.type.cleanName);
  }
}

export module API {
  export function fetchColorPalettes(): Promise<string[]> {
    return ajaxGet({ url: "~/api/chart/colorPalette" });
  }

  export function fetchColorPalette(typeName: string): Promise<ChartPaletteModel | null> {
    return ajaxGet({ url: `~/api/chart/colorPalette/${typeName}` });
  }

  export function saveColorPalette(model: ChartPaletteModel): Promise<void> {
    return ajaxPost({ url: `~/api/chart/colorPalette/${model.type.cleanName}/save`, }, model);
  }

  export function deleteColorPalette(typeName: string): Promise<void> {
    return ajaxPost({ url: `~/api/chart/colorPalette/${typeName}/delete` }, undefined);
  }

  export function newColorPalette(typeName: string, paletteType: string): Promise<void> {
    return ajaxPost({ url: `~/api/chart/colorPalette/${typeName}/new/${paletteType}`, }, undefined);
  }
}
