
namespace Game
{
    public static class Extentions
    {
        //здесь необходимо дополнить логикой выдачи разных склонений ключа, т.е. если ключ money и количество 22 то берётся ключ money_2-4 : "монеты"
        //в рамках задания для упрощения использован костыльный вариант с хардкодом
        public static string MultipleLocalizeText(this string key, int count)
        {
            var num = count % 10;
            if (num == 1)
                return "монета";
            else if (num >= 2 && num < 5)
                return "монеты";
            else
                return "монет";
        }

        public static void RemoveBySwap<T>(this List<T> list, int index)
        {
            list[index] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
        }
    }
}