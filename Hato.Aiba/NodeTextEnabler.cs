using MelonLoader;

namespace Hato.Aiba
{
    public class NodeTextEnabler : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Melon<NodeTextEnabler>.Logger.Msg("Hello World!");
        }

        public override void OnUpdate()
        {
            
        }
    }
}