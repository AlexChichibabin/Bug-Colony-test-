using System;
using System.Collections.Generic;

public interface IHasCapability
{
    bool TryGetCapability<T>(out T cap) where T : class;
}
