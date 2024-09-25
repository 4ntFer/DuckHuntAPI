using DuckHuntAPI.Models;
using DuckHuntAPI.ObjectFactory;
using DuckHuntAPI.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Utils
{
    // <summary>
    // Class <c>RepositoryAndObjectFactorySupplier<c> encapsulates and initializes repositories and ObjectFactory,
    // because to instaciate a ObjectFactory can be necessary instanciate others Repositories or ObjectFactory.
    // This implementation avoid code duplication. But It is recommend to put properties objects in local variables 
    // when access properties of this class if you want use that propertie object again.
    // </summary>
    public class RepositoryAndObjectFactorySupplier
    {
        private ISession _session;

        private AnimationRepository _animationRepository;
        private CharacterRepository _characterRepository;
        private ImageRepository _imageRepository;
        private ImageSeqRepository _imageSeqRepository;

        private AnimationGameObjectAttributesBuilder _animationObjectFactory;
        private CharacterGameObjectAttributesBuilder _characterObjectFactory;
        private ImageGameObjectAttributesBuilder _imageObjectFactory;


        public AnimationRepository animationRepository { get { return GetAnimationRepository(); } }
        public CharacterRepository characterRepository { get { return GetCharacterRepository(); } }
        public ImageRepository imageRepository { get { return GetImageRepository();  } }
        public ImageSeqRepository imageSeqRepository { get { return GetImageSeqRepository(); } }

        public AnimationGameObjectAttributesBuilder animationObjectFactory { get { return GetAnimationObjectFactory(); } }
        public CharacterGameObjectAttributesBuilder characterObjectFactory { get { return GetCharacterObjectFactory(); } }
        public ImageGameObjectAttributesBuilder imageObjectFactory { get { return GetImageObjectFactory(); } }

        public RepositoryAndObjectFactorySupplier(ISession session) {
            this._session = session;

            _animationRepository = null;
            _characterRepository = null;
            _imageRepository = null;
            _imageSeqRepository = null;

            _animationObjectFactory = null;
            _characterObjectFactory = null;
            _imageObjectFactory = null;
    }

        private AnimationRepository GetAnimationRepository() {
            if (_animationRepository == null) {
                _animationRepository = new AnimationRepository(_session);
            }

            return _animationRepository;
        }

        private CharacterRepository GetCharacterRepository() {
            if (_characterRepository == null) {
                _characterRepository = new CharacterRepository(_session);
            }

            return _characterRepository;
        }

        private ImageRepository GetImageRepository() {
            if (_imageRepository == null) {
                _imageRepository = new ImageRepository(_session);
            }

            return _imageRepository;
        }

        private ImageSeqRepository GetImageSeqRepository() {
            if (_imageSeqRepository == null) {
                _imageSeqRepository = new ImageSeqRepository(_session);
            }

            return _imageSeqRepository;
        }

        private ImageGameObjectAttributesBuilder GetImageObjectFactory() {
            if (_imageObjectFactory == null) {
                _imageObjectFactory = new ImageGameObjectAttributesBuilder(imageRepository);
            }

            return _imageObjectFactory;
        }

        private AnimationGameObjectAttributesBuilder GetAnimationObjectFactory () {
            if (_animationObjectFactory == null) {
                _animationObjectFactory = new AnimationGameObjectAttributesBuilder(imageSeqRepository, imageRepository);
            }

            return _animationObjectFactory;
        }

        private CharacterGameObjectAttributesBuilder GetCharacterObjectFactory() {
            if (_characterObjectFactory == null) {
                _characterObjectFactory = new CharacterGameObjectAttributesBuilder(characterRepository, animationRepository, animationObjectFactory);
            }

            return _characterObjectFactory;
        }
    }
}
