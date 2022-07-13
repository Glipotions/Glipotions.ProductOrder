﻿using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Glipotions.ProductOrder.Services;

public interface ICodeAppService<in TGetCodeInput> : IApplicationService
{
    Task<string> GetCodeAsync(TGetCodeInput input);
}