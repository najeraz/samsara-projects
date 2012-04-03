
using Samsara.Base.Service.Impl;
using Samsara.System.Core.Entities;
using Samsara.System.Core.Parameters;
using Samsara.System.Dao.Interfaces;
using Samsara.System.Service.Interfaces;

namespace Samsara.System.Service.Impl
{
    public class TextFormatService : BaseService<TextFormat, int, ITextFormatDao, TextFormatParameters>, ITextFormatService
    {
    }
}