using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing.Design;

namespace ESolutions.LifeLog.Web.UI
{
	public partial class ImageLinkButton : System.Web.UI.UserControl, IButtonControl
	{
		//Properties
		#region ImageUrl
		[Category("Appearance")]
		[Editor("System.Web.UI.Design.ImageUrlEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[UrlProperty]
		[Description("Image_ImageUrl")]
		[Bindable(true)]
		[DefaultValue("")]
		public virtual string ImageUrl
		{
			get
			{
				return this.Image1.ImageUrl;
			}
			set
			{
				this.Image1.ImageUrl = value;
			}
		}
		#endregion

		#region Text
		[DefaultValue("")]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		[Description("LinkButton_Text")]
		[Localizable(true)]
		[Bindable(true)]
		[Category("Appearance")]
		public String Text
		{
			get
			{
				return this.Label1.Text;
			}
			set
			{
				this.Label1.Text = value;
			}
		}
		#endregion

		#region CausesValidation
		public bool CausesValidation
		{
			get
			{
				return this.Button1.CausesValidation;
			}
			set
			{
				this.Button1.CausesValidation = value;
			}
		}
		#endregion

		#region CommandArgument
		public string CommandArgument
		{
			get
			{
				return this.Button1.CommandArgument;
			}
			set
			{
				this.Button1.CommandArgument = value;
			}
		}
		#endregion

		#region CommandName
		public string CommandName
		{
			get
			{
				return this.CommandName;
			}
			set
			{
				this.CommandName = value;
			}
		}
		#endregion

		#region PostBackUrl
		public string PostBackUrl
		{
			get
			{
				return this.Button1.PostBackUrl;
			}
			set
			{
				this.Button1.PostBackUrl = value;
			}
		}
		#endregion

		#region ValidationGroup
		public string ValidationGroup
		{
			get
			{
				return this.Button1.ValidationGroup;
			}
			set
			{
				this.Button1.ValidationGroup = value;
			}
		}
		#endregion

		//Events
		#region Click
		[Description("LinkButton_OnClick")]
		[Category("Action")]
		public event EventHandler Click;
		#endregion

		#region Command
		public event CommandEventHandler Command;
		#endregion

		//Methods
		#region Button1_Click
		protected void Button1_Click(Object sender, EventArgs e)
		{
			this.OnClick();
		}
		#endregion

		#region OnClick
		protected void OnClick()
		{
			if (this.Click != null)
			{
				this.Click(this, new EventArgs());
			}
		}
		#endregion

		#region OnCommand
		protected void OnCommand()
		{
			if (this.Command != null)
			{
				this.Command(this, new CommandEventArgs(this.CommandName, this.CommandArgument));
			}
		}
		#endregion
	}
}