using ESolutions.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ESolutions.LifeLog.Web.UI
{
	public partial class Main : ESolutions.Web.UI.MasterPage
	{
		#region Form
		public HtmlForm Form
		{
			get
			{
				return this.form1;
			}
		}
		#endregion

		#region OnInit
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if (this.Request.Browser.IsMobileDevice)
			{
				this.Response.Redirect("http://mobile.mylifelog.de");
			}

			if (
				this.Session.GetCurrentUser() == null &&
				(this.Page as ESolutions.Web.UI.Page).GetUrl() != PageUrlAttribute.Get<Default>() &&
				(this.Page as ESolutions.Web.UI.Page).GetUrl() != PageUrlAttribute.Get<LoginForm>() &&
				(this.Page as ESolutions.Web.UI.Page).GetUrl() != PageUrlAttribute.Get<Me.Create>())
			{
				this.ResponseAddOn.Redirect<Default>();
			}
		}
		#endregion

		#region Page_PreRender
		protected void Page_PreRender(object sender, EventArgs e)
		{
			if (this.Session.GetCurrentUser() == null)
			{
				this.SoulLink.Visible = false;
				this.BodyLink.Visible = false;
				this.HeartLink.Visible = false;
				this.ActionLink.Visible = false;
				this.FeastLink.Visible = false;
				this.MeLink.Visible = false;
				this.CurrentUserLabel.Visible = false;
				this.CurrentUserIntroLabel.Visible = false;
				this.NoCurrentUserLabel.Visible = true;
				this.CreateAccountLink.Visible = true;
				this.LoginLink.Visible = true;
				this.LogoutButton.Visible = false;
			}
			else
			{
				this.CurrentUserLabel.Visible = true;
				this.CurrentUserIntroLabel.Visible = true;
				this.NoCurrentUserLabel.Visible = false;
				this.CurrentUserLabel.Text = this.Session.GetCurrentUser() == null ? String.Empty : this.Session.GetCurrentUser().Email;
				this.LoginLink.Visible = false;
				this.LogoutButton.Visible = true;
				this.CreateAccountLink.Visible = false;
			}

			this.HomeLink.NavigateUrl = PageUrlAttribute.Get<Default>();
			this.SoulLink.NavigateUrl = PageUrlAttribute.Get<Soul.Default>();
			this.BodyLink.NavigateUrl = PageUrlAttribute.Get<Body.Default>();
			this.HeartLink.NavigateUrl = PageUrlAttribute.Get<Heart.Default>();
			this.ActionLink.NavigateUrl = PageUrlAttribute.Get<Action.Default>();
			this.FeastLink.NavigateUrl = PageUrlAttribute.Get<Feast.Default>();
			this.LoginLink.NavigateUrl = PageUrlAttribute.Get<LoginForm>();
			this.MeLink.NavigateUrl = PageUrlAttribute.Get<Me.Default>();
			this.CreateAccountLink.NavigateUrl = PageUrlAttribute.Get<Me.Create>();
		}
		#endregion

		#region LogoutButton_Click
		protected void LogoutButton_Click(Object sender, EventArgs e)
		{
			this.Session.SetCurrentUser(null);
			this.ResponseAddOn.Redirect<Default>();
		}
		#endregion

		#region Page_Load
		protected void Page_Load(Object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.ErrorLabel.Visible = false;
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
