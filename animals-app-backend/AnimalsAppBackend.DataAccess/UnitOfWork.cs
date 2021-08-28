using AnimalsAppBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAppBackend.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AnimalsAppDbContext _animalsAppDbContext;

        private GenericRepository<User> _users;

        private GenericRepository<UserDetails> _userDetails;

        private GenericRepository<Post> _post;

        private GenericRepository<PostImage> _postImage;

        public UnitOfWork(AnimalsAppDbContext animalsAppDbContext)
        {
            _animalsAppDbContext = animalsAppDbContext;
        }

        public IGenericRepository<User> Users
        {
            get
            {
                return _users ??
                    (_users = new GenericRepository<User>(_animalsAppDbContext));
            }
        }

        public IGenericRepository<UserDetails> UserDetails
        {
            get
            {
                return _userDetails ??
                    (_userDetails = new GenericRepository<UserDetails>(_animalsAppDbContext));
            }
        }

        public IGenericRepository<Post> Posts
        {
            get
            {
                return _post ??
                    (_post = new GenericRepository<Post>(_animalsAppDbContext));
            }
        }

        public IGenericRepository<PostImage> PostImages
        {
            get
            {
                return _postImage ??
                    (_postImage = new GenericRepository<PostImage>(_animalsAppDbContext));
            }
        }

        public async Task SaveChangesAsync()
        {
            await _animalsAppDbContext.SaveChangesAsync();
        }
    }
}
