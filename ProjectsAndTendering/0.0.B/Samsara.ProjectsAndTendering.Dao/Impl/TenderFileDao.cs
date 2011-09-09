
using System;
using System.Collections;
using System.Data.SqlTypes;
using System.IO;
using NHibernate;
using NHibernate.Impl;
using Samsara.Base.Dao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;

namespace Samsara.ProjectsAndTendering.Dao.Impl
{
    public class TenderFileDao : GenericDao<TenderFile, int, TenderFileParameters>, ITenderFileDao
    {
        #region Methods

        #region Public

        public override TenderFile GetById(int tenderFileId)
        {
            TenderFile entity = base.GetById(tenderFileId);
            
            if (entity != null)
                this.GetTenderFileByFileStream(entity);

            return entity;
        }

        public override void Save(TenderFile entity)
        {
            base.Save(entity);
            this.SaveTenderFileByFileStream(entity);
        }

        public override void SaveOrUpdate(TenderFile entity)
        {
            base.SaveOrUpdate(entity);
            this.SaveTenderFileByFileStream(entity);
        }

        public override void Update(TenderFile entity)
        {
            base.Update(entity);
            this.SaveTenderFileByFileStream(entity);
        }

        #endregion Public

        #region Private

        private void GetTenderFileByFileStream(TenderFile entity)
        {
            if (entity.File.Length > 8000) // Por algun motivo trae el archivo completo
                return;

            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    SqlFileStream sqlFileStream = this.GetSqlFileStream(entity.TenderFileId, session, FileAccess.Read);

                    byte[] buffer = new Byte[sqlFileStream.Length];
                    sqlFileStream.Read(buffer, 0, buffer.Length);

                    MemoryStream ms = new MemoryStream(buffer);
                    entity.File = ms.ToArray();

                    sqlFileStream.Close();
                    transaction.Commit();
                    session.Close();
                }
            }
        }

        private void SaveTenderFileByFileStream(TenderFile entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    SqlFileStream sqlFileStream = this.GetSqlFileStream(entity.TenderFileId, session, FileAccess.Write);

                    sqlFileStream.Write(entity.File, 0, entity.File.Length);

                    sqlFileStream.Close();
                    transaction.Commit();
                    session.Close();
                }
            }
        }

        private SqlFileStream GetSqlFileStream(int tenderFileId, ISession session, FileAccess fileAccess)
        {
            TenderFileParameters pmtTenderFile = new TenderFileParameters();
            pmtTenderFile.TenderFileId = tenderFileId;

            DetachedNamedQuery dnq = this.GetDetachedNamedQuery("GetTenderFileStreamContext", pmtTenderFile);
            Object[] objTenderFileStreamContext = dnq.GetExecutableQuery(session).UniqueResult() as Object[];

            string filePath = objTenderFileStreamContext[0] as string;
            byte[] txContext = objTenderFileStreamContext[1] as Byte[];

            return new SqlFileStream(filePath, txContext, fileAccess);
        }

        #endregion Private

        #endregion Methods
    }
}