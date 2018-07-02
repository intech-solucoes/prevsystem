namespace Intech.PrevSystem.Preves.API.Relatorios
{
    partial class CertificadoDeRegistroNoPlano
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificadoDeRegistroNoPlano));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.dataSet1 = new System.Data.DataSet();
            this.TABLE_RELATORIO = new System.Data.DataTable();
            this.NOM_PARTICIPANTE = new System.Data.DataColumn();
            this.COD_CPF = new System.Data.DataColumn();
            this.NOM_PLANO = new System.Data.DataColumn();
            this.COD_CNPB = new System.Data.DataColumn();
            this.NUM_INSCRICAO = new System.Data.DataColumn();
            this.DTA_REGISTRO = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TABLE_RELATORIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText1,
            this.xrPictureBox1});
            this.Detail.HeightF = 842.7083F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrRichText1
            // 
            this.xrRichText1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(86.04167F, 280.5417F);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
            this.xrRichText1.SizeF = new System.Drawing.SizeF(959.7917F, 216.75F);
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageUrl = "~/wwwroot/img/certificadoDeRegistroNoPlano.png";
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(1.333374F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(1091.667F, 771.875F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 10F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 1.250013F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.TABLE_RELATORIO});
            // 
            // TABLE_RELATORIO
            // 
            this.TABLE_RELATORIO.Columns.AddRange(new System.Data.DataColumn[] {
            this.NOM_PARTICIPANTE,
            this.COD_CPF,
            this.NOM_PLANO,
            this.COD_CNPB,
            this.NUM_INSCRICAO,
            this.DTA_REGISTRO});
            this.TABLE_RELATORIO.TableName = "TABLE_RELATORIO";
            // 
            // NOM_PARTICIPANTE
            // 
            this.NOM_PARTICIPANTE.ColumnName = "NOM_PARTICIPANTE";
            // 
            // COD_CPF
            // 
            this.COD_CPF.ColumnName = "COD_CPF";
            // 
            // NOM_PLANO
            // 
            this.NOM_PLANO.ColumnName = "NOM_PLANO";
            // 
            // COD_CNPB
            // 
            this.COD_CNPB.ColumnName = "COD_CNPB";
            // 
            // NUM_INSCRICAO
            // 
            this.NUM_INSCRICAO.ColumnName = "NUM_INSCRICAO";
            // 
            // DTA_REGISTRO
            // 
            this.DTA_REGISTRO.ColumnName = "DTA_REGISTRO";
            // 
            // CertificadoDeRegistroNoPlano
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.DataMember = "TABLE_RELATORIO";
            this.DataSource = this.dataSet1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(20, 56, 10, 1);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "13.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TABLE_RELATORIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable TABLE_RELATORIO;
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
        private System.Data.DataColumn NOM_PARTICIPANTE;
        private System.Data.DataColumn COD_CPF;
        private System.Data.DataColumn NOM_PLANO;
        private System.Data.DataColumn COD_CNPB;
        private System.Data.DataColumn NUM_INSCRICAO;
        private System.Data.DataColumn DTA_REGISTRO;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
    }
}
