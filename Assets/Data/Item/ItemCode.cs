using System;
using UnityEngine;

public enum ItemCode
{
    NoItem = 0,

    IronOre = 1,
    GoldOre = 2,

    CopperSword = 1000,
}

public class ItemCodeParser // Hàm để xử lý việc phân tích mã vật phẩm
{
    public static ItemCode FromString(string itemName) // Phương thức tĩnh để phân tích mã vật phẩm từ chuỗi
    {

        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName); // Phân tích chuỗi thành enum
        }
        catch (ArgumentException e) // Bắt lỗi trong quá trình phân tích
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    } 
}  