using VisualApp.Models;
using VisualApp.ViewModels.Base;

namespace VisualApp.ViewModels
{
    public class PowerStatsViewModel : DetailsViewModel<PowerStats>
    {
        public int? Intelligence => CurrentEntity.Intelligence;
        public int? Strength => CurrentEntity.Strength;
        public int? Speed => CurrentEntity.Speed;
        public int? Durability => CurrentEntity.Durability;
        public int? Power => CurrentEntity.Power;
        public int? Combat => CurrentEntity.Combat;

        public PowerStatsViewModel( PowerStats powerStats ) : base( powerStats )
        {
        }
    }
}
