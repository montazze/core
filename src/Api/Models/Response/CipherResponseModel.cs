﻿using System;
using Bit.Core.Domains;

namespace Bit.Api.Models
{
    public class CipherResponseModel : ResponseModel
    {
        public CipherResponseModel(Cipher cipher)
            : base("cipher")
        {
            if(cipher == null)
            {
                throw new ArgumentNullException(nameof(cipher));
            }

            Id = cipher.Id.ToString();
            FolderId = cipher.FolderId?.ToString();
            Type = cipher.Type;
            Favorite = cipher.Favorite;
            RevisionDate = cipher.RevisionDate;

            switch(cipher.Type)
            {
                case Core.Enums.CipherType.Folder:
                    Data = new FolderDataModel(cipher);
                    break;
                case Core.Enums.CipherType.Site:
                    Data = new SiteDataModel(cipher);
                    break;
                default:
                    throw new ArgumentException("Unsupported " + nameof(Type) + ".");
            }
        }

        public string Id { get; set; }
        public string FolderId { get; set; }
        public Core.Enums.CipherType Type { get; set; }
        public bool Favorite { get; set; }
        public dynamic Data { get; set; }
        public DateTime RevisionDate { get; set; }
    }
}
