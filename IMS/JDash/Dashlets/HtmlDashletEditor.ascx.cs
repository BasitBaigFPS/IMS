using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JDash.WebForms;

namespace IMS.JDash.Dashlets
{
    public partial class HtmlDashletEditor : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        DashletContext context = null;

        public override void DataBind()
        {
            htmlInput.Text = context.Model.config.Get<string>("html", "");
            base.DataBind();
        }

        [JEventHandler(JEvent.InitContext)]
        public void InitContext(object sender, JEventArgs args)
        {
            this.context = args.Event.Parameters.Get<DashletContext>("context");
        }

        [JEventHandler(JEvent.ValidateDashletEditor)]
        public void ValidateDashletEditor(object sender, JEventArgs args)
        {
            context.Model.config["html"] = htmlInput.Text;
            context.SaveModel();
            context.DashletControl.DataBind();
        }
    }
}