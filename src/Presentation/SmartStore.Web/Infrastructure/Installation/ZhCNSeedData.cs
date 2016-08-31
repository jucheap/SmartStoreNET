using System.Collections.Generic;
using System.Linq;
using SmartStore.Core.Configuration;
using SmartStore.Core.Domain.Cms;
using SmartStore.Core.Domain.Media;
using SmartStore.Data.Setup;

namespace SmartStore.Web.Infrastructure.Installation
{

    public class ZhCnSeedData : InvariantSeedData
    {

		public ZhCnSeedData()
        {
        }

        protected override void Alter(IList<ISettings> settings)
        {
            base.Alter(settings);

            settings
                .Alter<ContentSliderSettings>(x =>
                {
					var slidePics = DbContext.Set<Picture>().ToList();

					var slide1PicId = slidePics.First(p => p.SeoFilename == GetSeName("slide-1")).Id;
					var slide2PicId = slidePics.First(p => p.SeoFilename == GetSeName("slide-2")).Id;
					var slide3PicId = slidePics.First(p => p.SeoFilename == GetSeName("slide-3")).Id;

                    //slide 1
                    x.Slides.Add(new ContentSliderSlideSettings
                    {
                        DisplayOrder = 1,
                        //LanguageName = "中文",
                        Title = "iPhone 即将发生重大改变",
                        Text = @"<ul>
                                    <li>更薄, 更轻</li>
                                    <li>4寸的视网膜显示屏.</li>
                                    <li>超快的移动数据.</li>                       
                                </ul>",
                        Published = true,
                        LanguageCulture = "en-US",
                        PictureId = slide1PicId,
                        Button1 = new ContentSliderButtonSettings
                        {
                            Published = true,
                            Text = "更多...",
                            Type = "btn-primary",
                            Url = "~/iphone-5"
                        },
                        Button2 = new ContentSliderButtonSettings
                        {
                            Published = true,
                            Text = "立即购买",
                            Type = "btn-danger",
                            Url = "~/iphone-5"
                        },
                        Button3 = new ContentSliderButtonSettings
                        {
                            Published = false
                        }
                    });
                    //slide 2
                    x.Slides.Add(new ContentSliderSlideSettings
                    {
                        DisplayOrder = 2,
                        //LanguageName = "English",
                        Title = "线上购买音乐!",
                        Text = @"<p>购买后立即下载.</p>
                                 <p>320 kbit/s  最好的音质.</p>
                                 <p>更快的下载速度.</p>",
                        Published = true,
                        LanguageCulture = "zh-CN",
                        PictureId = slide2PicId,
                        Button1 = new ContentSliderButtonSettings
                        {
                            Published = true,
                            Text = "更多...",
                            Type = "btn-warning",
                            Url = "~/musik-kaufen-sofort-herunterladen"
                        },
                        Button2 = new ContentSliderButtonSettings
                        {
                            Published = false
                        },
                        Button3 = new ContentSliderButtonSettings
                        {
                            Published = false
                        }
                    });
                    //slide 3
                    x.Slides.Add(new ContentSliderSlideSettings
                    {
                        DisplayOrder = 3,
                        //LanguageName = "English",
                        Title = "为革命做好准备了吗?",
                        Text = @"<p>SmartStore.NET is the new dynamic E-Commerce solution from SmartStore.</p>
                                 <ul>
                                     <li>Order-, customer- and stock-management.</li>
                                     <li>SEO optimized | 100% mobile optimized.</li>
                                     <li>Reviews &amp; Ratings | SmartStore.biz Import.</li>
                                 </ul>",
                        Published = true,
                        LanguageCulture = "zh-CN",
                        PictureId = slide3PicId,
                        Button1 = new ContentSliderButtonSettings
                        {
                            Published = true,
                            Text = "更多...",
                            Type = "btn-success",
                            Url = "http://net.smartstore.com"
                        },
                        Button2 = new ContentSliderButtonSettings
                        {
                            Published = false
                        },
                        Button3 = new ContentSliderButtonSettings
                        {
                            Published = false
                        }
                    });
                });
        }


    }

}
