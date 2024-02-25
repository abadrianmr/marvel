using VisualApp.Models;
using VisualApp.ViewModels.Base;

namespace VisualApp.ViewModels.Navigation
{
    public class HeroViewModel : DetailsViewModel<Hero>
    {

        public string Name => CurrentEntity.Name;

        public Image Image => CurrentEntity.Image;

        public PowerStats PowerStats => CurrentEntity.PowerStats;

        public HeroViewModel( Hero hero ) : base( hero )
        {

        }
    }
}
