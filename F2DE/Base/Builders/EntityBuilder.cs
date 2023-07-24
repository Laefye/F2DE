using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.Builders
{
    internal class EntityBuilder
    {
        private List<Type> components = new List<Type>();
        private List<Action<Entity>> posts = new List<Action<Entity>>();

        public EntityBuilder Add<C>() where C : EntityComponent
        {
            components.Add(typeof(C));
            return this;
        }

        public EntityBuilder Post(Action<Entity> post)
        {
            posts.Add(post);
            return this;
        }

        public Entity Build(Instance instance)
        {
            var entity = new Entity(instance);
            foreach (var component in components)
            {
                entity.AddComponent(component);
            }
            foreach (var post in posts)
            {
                post.Invoke(entity);
            }
            return entity;
        }
    }
}
