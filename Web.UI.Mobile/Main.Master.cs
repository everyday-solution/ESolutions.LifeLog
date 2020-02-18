using ESolutions.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESolutions.LifeLog.Web.UI.Mobile
{
	public partial class Main : ESolutions.Web.UI.MasterPage
	{
		#region OnInit
		protected override void OnInit(EventArgs e)
		{
			if (this.Session.GetCurrentUser() == null)
			{
				this.ResponseAddOn.Redirect<Login>();
			}
			base.OnInit(e);
		}
		#endregion

		#region Page_Load
		protected void Page_Load(Object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
				}
				else
				{
					this.ErrorLabel.Visible = false;
				}
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region Page_PreRender
		protected void Page_PreRender(Object sender, EventArgs e)
		{
			try
			{
				this.HomeLink.NavigateUrl = PageUrlAttribute.Get<Default>();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region ShowError
		public void ShowError(Exception ex)
		{
#if DEBUG
			this.ErrorLabel.Text = ex.DeepParse();
#else
			this.ErrorLabel.Text = ex.Message;
#endif
			this.ErrorLabel.Visible = true;
		}
		#endregion
	}
}