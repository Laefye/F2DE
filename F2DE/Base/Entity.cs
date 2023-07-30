using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using F2DE.Base.Components;
using F2DE.Base.Interfaces;

namespace F2DE.Base
{
    internal class Entity : ITickable, IRenderTickable, IPost, IDisposable
    {
        public Instance instance;
        private List<EntityComponent> components = new List<EntityComponent>();

        public Entity(Instance instance)
        {
            this.instance = instance;
        }

        public void RenderTick(string layer)
        {
            foreach (var component in components)
            {
                if (component.GetType().IsAssignableTo(typeof(IRenderTickable)))
                {
                    ((IRenderTickable)component).RenderTick(layer);
                }
            }
        }

        private void Tick(Type interf, string method)
        {
            foreach (var component in components)
            {
                if (component.GetType().IsAssignableTo(interf))
                {
                    interf.GetMethod(method)?.Invoke(component, null);
                }
            }
        }

        public void Tick()
        {
            Tick(typeof(ITickable), "Tick");
        }

        public void Dispose()
        {
            Tick(typeof(IDisposable), "Dispose");
        }

        public C? GetComponent<C>() where C : EntityComponent
        {
            foreach (var component in components)
            {
                if (component.GetType().IsAssignableTo(typeof(C)))
                {
                    return (C)component;
                }
            }
            return null;
        }

        public EntityComponent AddComponent(Type type)
        {
            var component = type.GetConstructor(new Type[] { typeof(Entity) })!.Invoke(new object[] {this});
            components.Add((EntityComponent) component);
            return (EntityComponent)component;
        }

        public void Post()
        {
            Tick(typeof(IPost), "Post");
        }
    }
}
