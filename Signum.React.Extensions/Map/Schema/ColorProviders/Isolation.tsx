﻿import * as d3 from 'd3'
import { ClientColorProvider, TableInfo  } from '../SchemaMap'
import { Dic } from '@framework/Globals'
import { EntityData, EntityKind } from '@framework/Reflection'
import { RoleEntity } from '../../../Authorization/Signum.Entities.Authorization'
export default function getDefaultProviders(info: TableInfo[]): ClientColorProvider[]{
    return [
        {
            name: "namespace",
            getFill: t => t.extra["isolation"] == undefined ? "white" :
                t.extra["isolation"] == "Isolated" ? "#CC0099" :
                    t.extra["isolation"] == "Optional" ? "#9966FF" :
                        t.extra["isolation"] == "None" ? "#00CCFF" : "black",
            getTooltip: t => t.extra["isolation"] == undefined ? undefined : t.extra["isolation"]
        }
    ];
}


