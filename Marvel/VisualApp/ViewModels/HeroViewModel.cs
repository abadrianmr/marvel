using VisualApp.Models;
using VisualApp.ViewModels.Base;

namespace VisualApp.ViewModels.Navigation
{
    public class HeroViewModel : DetailsViewModel<Hero>
    {

        public string Name => CurrentEntity.Name;

        public Image Image => CurrentEntity.Image;

        public PowerStatsViewModel PowerStats { get; }

        public HeroViewModel( Hero hero ) : base( hero )
        {
            PowerStats = new PowerStatsViewModel( CurrentEntity.PowerStats );
        }
    }
}
