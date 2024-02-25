using Prism.Mvvm;

namespace VisualApp.ViewModels.Base
{
    /// <summary>
    /// Clase base para los detalles de un elementos genérico.
    /// </summary>
    /// <typeparam name="T">
    /// Tipo de elementos.
    /// </typeparam>
    public abstract class DetailsViewModel<T> : BindableBase
    {
        /// <summary>
        /// Elemento actual.
        /// </summary>
        public T CurrentEntity { get; protected set; }

        /// <summary>
        /// Inicializa un objeto <see cref="DetailsViewModel{T}"/>.
        /// </summary>
        /// <param name="currentEntity">
        /// Un objeto conteniendo la información del elemento.
        /// </param>
        protected DetailsViewModel( T currentEntity )
        {
            CurrentEntity = currentEntity;
        }
    }

}
