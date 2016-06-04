﻿using Sitecore.Mvc.Presentation;
using Sitecore.Sites;
using Synthesis.FieldTypes.Adapters;

namespace Synthesis.Mvc.UI
{
	public class SitecoreRenderingContext : IRenderingContext
	{
		public TItem GetRenderingDatasource<TItem>() where TItem : class, IStandardTemplateItem
		{
			return RenderingContext.Current.Rendering.Item.As<TItem>();
		}

		public TItem GetContextItem<TItem>() where TItem : class, IStandardTemplateItem
		{
			return Sitecore.Context.Item.As<TItem>();
		}

		public IStandardTemplateItem ContextItem => Sitecore.Context.Item.AsStronglyTyped();
		public IStandardTemplateItem RenderingDatasource => RenderingContext.Current.Rendering.Item.AsStronglyTyped();

		public bool IsEditing => Sitecore.Context.Site.DisplayMode == DisplayMode.Edit;
		public bool IsPreview => Sitecore.Context.Site.DisplayMode == DisplayMode.Preview;
		public bool IsNormal => Sitecore.Context.Site.DisplayMode == DisplayMode.Normal;
		public bool IsExperienceExplorer => Sitecore.ExperienceExplorer.Business.Managers.ModuleManager.IsExpViewModeActive;
		public bool IsDebugging => Sitecore.Context.PageMode.IsDebugging || Sitecore.Context.Diagnostics.Profiling || Sitecore.Context.Diagnostics.Tracing;
		public bool IsCompletelyNormal => IsNormal && !IsExperienceExplorer && !IsDebugging;

		public SiteContext ContextSite => Sitecore.Context.Site;
		public IDatabaseAdapter ContextDatabase => new DatabaseAdapter(Sitecore.Context.ContentDatabase ?? Sitecore.Context.Database);
	}
}
