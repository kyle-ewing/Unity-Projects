
using System.Threading.Tasks;

namespace FrozenCircle.Core.Utils
{
    public interface IInitializable
    {
        // TODO: Refactor this to be UniTask
        public Task Initialize();
    }
}