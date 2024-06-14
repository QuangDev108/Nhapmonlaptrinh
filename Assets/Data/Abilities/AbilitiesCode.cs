using System;
using UnityEngine;

public enum AbilitiesCode
{
    NoAbility = 0,

    Missle = 1,
    Laze = 2,
}

public class AbilitiesCodeParser // Hàm để xử lý việc phân tích mã vật phẩm
{
    public static AbilitiesCode FromString(string itemName) // Phương thức tĩnh để phân tích mã vật phẩm từ chuỗi
    {

        try
        {
            return (AbilitiesCode)System.Enum.Parse(typeof(AbilitiesCode), itemName); // Phân tích chuỗi thành enum
        }
        catch (ArgumentException e) // Bắt lỗi trong quá trình phân tích
        {
            Debug.LogError(e.ToString());
            return AbilitiesCode.NoAbility;
        }
    } 
}  