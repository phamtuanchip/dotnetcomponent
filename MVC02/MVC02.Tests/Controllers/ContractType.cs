using System;

namespace MVC02.Tests.Controllers
{
    public class ContractType : AntiFogDaoModel, INamedObject {

        public string ContractCode { get; set; }
        
        public Guid NameId { get; set; }
        public virtual Translatable Name { get; set; }

        public bool OnlyForInternalEmployee { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        #region equality
        public override bool Equals(object obj)
        {
            ContractType that = obj as ContractType;
            if (that == null) return false;
            return this.Equals(that);
        }

        public bool Equals(ContractType that)
        {
            return this.Name.Equals(that.Name)
                && this.ContractCode == that.ContractCode
                && this.CompanyId == that.CompanyId;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = 31 * hash + (this.Name == null ? 0 : this.Name.GetHashCode());
            hash = 31 * hash + (this.ContractCode == null ? 0 : this.ContractCode.GetHashCode());
            hash = 31 * hash + (this.CompanyId == null ? 0 : this.CompanyId.GetHashCode());
            return hash;
        }
        #endregion equality
    }

     
}
