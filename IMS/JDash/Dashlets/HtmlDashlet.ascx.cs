using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JDash.WebForms;

namespace IMS.JDash.Dashlets
{
    public partial class HtmlDashlet : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private DashletContext context;

        [JEventHandler(JEvent.InitContext)]
        public void InitContext(object sender, JEventArgs args)
        {
            this.context = args.Event.Parameters.Get<DashletContext>("context");
        }

        public override void DataBind()
        {
            var htmlString = context.Model.config.Get<string>("html", "");
            htmlLit.Text = htmlString;
            context.RenderDashlet();
            base.DataBind();
        }
    }
}