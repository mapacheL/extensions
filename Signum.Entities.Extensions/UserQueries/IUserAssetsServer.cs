﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using Signum.Entities;
using Signum.Entities.UserQueries;
using Signum.Services;

namespace Signum.Services
{
    [ServiceContract]
    public interface IUserAssetsServer
    {
        [OperationContract, NetDataContract]
        byte[] ExportAsset(Lite<IUserAssetEntity> asset);

        [OperationContract, NetDataContract]
        List<UserAssetPreview> PreviewAssetImport(byte[] document);

        [OperationContract, NetDataContract]
        void AssetImport(byte[] document, List<UserAssetPreview> previews);
    }
}
