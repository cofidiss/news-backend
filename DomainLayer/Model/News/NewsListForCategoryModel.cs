﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model.News
{
    public class NewsListForCategoryModel
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public DateTime UploadDate { get; set; }
        public bool IsDeletable { get; set; }
    }
}
