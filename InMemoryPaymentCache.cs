using System;

namespace provide_webapi;

public sealed class InMemoryPaymentCache
{
    private readonly ILogger<InMemoryPaymentCache> _logger;
    public InMemoryPaymentCache(ILogger<InMemoryPaymentCache> logger)
    {
        _logger = logger;
    }
    private Dictionary<Guid, Guid> Cache { get; } = new Dictionary<Guid, Guid>();

    public void Add(Guid paymentId, Guid tmpGuid)
    {
        _logger.LogInformation("Added. paymentId:{0}, key:{1}", paymentId, tmpGuid);
        Cache.Add(paymentId, tmpGuid);
    }

    public bool Verify(Guid paymentId, Guid tmpGuid)
    {
        _logger.LogInformation("Verified. paymentId:{0}, key:{1}", paymentId, tmpGuid);
        return Cache.ContainsKey(paymentId) && Cache.ContainsValue(tmpGuid);
    }

    public void Remove(Guid paymentId)
    {
        Cache.Remove(paymentId);
    }
}
