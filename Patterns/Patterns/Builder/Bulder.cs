using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Builder
{
    public class Handler
    {
			public void Build(BulderBase builder)
				{
					if (builder == null)
						return;

					builder.Build();
				}
    }

    public abstract class BulderBase
    {
        public Document Doc
        {
            get;
            protected set;
        }


				public BulderBase()
        {
            
        }


        public virtual void Build()
        {
					if (Doc == null)
            Doc = new Document();
        }

    }


		public class ImagesBuilder : BulderBase
		{
			private Image unit;
			public ImagesBuilder()
			{
				unit = new Image();
			}

			public override void Build()
			{
				base.Build();
				Doc.images.Add(unit);
			}

		}

		public class DocxBuilder : BulderBase
		{
			private DOCX unit;
			public DocxBuilder()
			{
				unit = new DOCX();
			}

			public override void Build()
			{
				base.Build();
				Doc.docx.Add(unit);
			}

		}

		public class XLSBuilder : BulderBase
		{
			private XLS unit;
			public XLSBuilder()
			{
				unit = new XLS();
			}

			public override void Build()
			{
				base.Build();
				Doc.xls.Add(unit);
			}

		}


    public class Document : Doc
    {
        public List<Image> images = new List<Image>();
        public List<XLS> xls = new List<XLS>();
        public List<DOCX> docx = new List<DOCX>();


        public override string ToString()
        {
					StringBuilder builder = new StringBuilder();

            foreach (var item in images)
                builder.Append(" " + item.ToString());

            foreach (var item in xls)
							builder.Append(" " + item.ToString());

            foreach (var item in docx)
							builder.Append(" " + item.ToString());

						return builder.ToString();
        }
        
    }

    public  class Doc
    {
        public override string ToString()
        {
					return "Doc";
        }
    }

    public class Image : Doc
    {
        public override string ToString()
        {
            return "Image";
        }
    }

    public class XLS : Doc
    {
        public override string ToString()
        {
					return "XLS";
        }
    }

    public class DOCX : Doc
    {
        public override string ToString()
        {
					return "DOCX";
        }
    }

}
