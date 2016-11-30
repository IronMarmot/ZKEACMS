/* http://www.zkea.net/ Copyright 2016 ZKEASOFT http://www.zkea.net/licenses */
using System;
using System.Collections.Generic;
using Easy.MetaData;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZKEACMS.SectionWidget.Models
{
    [ViewConfigure(typeof(SectionContentTitleMetaData)), Table("SectionContentTitle")]
    public class SectionContentTitle : SectionContent
    {
        public const string H1 = "h1";
        public const string H2 = "h2";
        public const string H3 = "h3";
        public const string H4 = "h4";
        public const string H5 = "h5";
        public const string H6 = "h6";
        public string InnerText { get; set; }
        public string Href { get; set; }
        public string TitleLevel { get; set; }
        public override int SectionContentType
        {
            get
            {
                return (int)Types.Title;
            }
        }
    }

    class SectionContentTitleMetaData : ViewMetaData<SectionContentTitle>
    {

        protected override void ViewConfigure()
        {
            ViewConfig(m => m.InnerText).AsTextBox().Required();
            ViewConfig(m => m.Href).AsTextBox().AddClass("select").AddProperty("data-url", Urls.SelectPage);
            ViewConfig(m => m.TitleLevel).AsDropDownList().DataSource(() => new Dictionary<string, string>
            {
                {SectionContentTitle.H1,"一级标题"},
                {SectionContentTitle.H2,"二级标题"},
                {SectionContentTitle.H3,"三级标题"},
                {SectionContentTitle.H4,"四级标题"},
                {SectionContentTitle.H5,"五级标题"},
                {SectionContentTitle.H6,"六级标题"}
            });
        }
    }
}