using System;

namespace RemoteCongress.Server.DAL.Blockchain
{
    public abstract class BaseBlockchain<TBlock>
        where TBlock: BaseBlock
    {
    }
}
