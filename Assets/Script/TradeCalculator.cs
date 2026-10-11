
using UnityEngine;

public static class TradeCalculator
{
    // 내구도 반영 실제 가치
    public static int CalculateValue(
        int basePrice,
        int durability)
    {
        float t = Mathf.InverseLerp(1, 100, durability);
        float multiplier = Mathf.Lerp(0.75f, 1.10f, t);

        return Mathf.RoundToInt(basePrice * multiplier);
    }

    // 흥정력에 따른 허용 범위
    public static float CalculateNegotiationRange(
        int level,
        int maxLevel)
    {
        float t = Mathf.InverseLerp(1, maxLevel, level);
        return Mathf.Lerp(0.10f, 0.50f, t);
    }

    // 손님별 허용 한도 생성
    public static float GenerateTolerance(float range)
    {
        return Random.Range(-range, range);
    }

    // 손님의 최소 허용 가격
    public static int CalculateMinimumPrice(
        int actualValue,
        float tolerance)
    {
        return Mathf.CeilToInt(actualValue * (1f + tolerance));
    }

    // 최초 요구 가격
    public static int GenerateAskingPrice(int minimumPrice)
    {
        float markup = Random.Range(0f, 0.30f);
        return Mathf.CeilToInt(minimumPrice * (1f + markup));
    }

    // 플레이어가 손님에게 장비를 구매하는 경우
    public static bool CanBuy(
        int playerOffer,
        int minimumPrice)
    {
        return playerOffer >= minimumPrice;
    }
}
