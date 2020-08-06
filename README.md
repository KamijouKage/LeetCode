{%hackmd theme-dark %}

# LeetCode 

###### tags: `LeetCode`

[![hackmd-github-sync-badge](https://hackmd.io/NBIF1YT4QtmSJ3Ju1r4ljQ/badge)](https://hackmd.io/NBIF1YT4QtmSJ3Ju1r4ljQ)

## #1_Two Sum 
###### Related Topics: `Hash Table`
### 目標
給一個int陣列nums跟一個int target，nums當中會有兩個值合為target，且是唯一解
求那兩個值在nums中的index n, m，然後回傳int[] {n, m}
### 求解
- 查表法:
    nums[i] + nums[j] == taget → nums[j] == target - nums[i]
    尋找合為target的兩數這件是其實相當於尋找target減去nums某值得到的數X存不存在nums中，所以可以思考把nums的數存成一個Dictionary，key是數值value是對應的index，這樣可以在一層迴圈中一邊建表一邊搜尋X來把問題解決

## #2_Add Two Numbers
###### Related Topics: `Linked List`
### 目標
給兩個LinkedList，將兩邊的Node各別相加串成新的LinkedList回傳，如果相加超過10則要進位給下個Node，可能會有兩個LinkedList長度不一樣的情況
### 求解
- 直觀流程
    1. 建立一個回傳用的LinkedList，三個遍訪用的Node nodeCurrent, nodeA跟B
    2. 進入while結束條件是nodeA, B兩個都見底(next == null)
    3. 如果nodeCurrent見底，補一個空node上去
    4. 檢查nodeA, B本身還有沒有值，有就把值加在nodeCurrent.next上，然後next
    5. nodeCurrent做next，處理進位(有進位會在這時就補上新的next，所以3.那邊才要做檢查，如果3.不檢查直接新增會覆蓋這邊進位就新增的next
    6. 跑完while，return 回傳用的LinkedList.next(這裡會是next是因為第一個相加的node就是放在itCurrent.next上)
- 優化
    1. 建立一個sum，先將nodeA, B的合算在sum上再把sum當next串上去，這樣可以不做3.
    2. 串next時用sum%10然後再把sum/10留到下一輪迴圈累加這樣可以不做5.進位處理
    3. 如果你用了上面的方法，這樣可能會漏掉最後一次的進位所以迴圈結束要檢查sum有沒有值要不要串next

## #3_Longest Substring Without Repeating Characters
###### Related Topics: `Sliding Window`
### 目標
給一個字串s，找出最長不含重複字元的substring長度
### 求解
- 暴力法
    雙迴圈尋遍所有s[i]起點到s[j]終點的substring
- Sliding Window
    - 解釋
        定義兩個數str, end，0 <= str, end < array.Length and str <= end
        這樣會在陣列中形成一個窗，照條件縮放移動來掃描陣列，就能以單層迴圈搞定題目
    - 應用
        1. 宣告str, maxLength
        2. For迴圈，平常用的i作為end從0到s.Length - 1
        3. 求這次迴圈的窗戶長度 nowLength = end - str + 1
        4. 嘗試擴大窗戶，檢查這窗戶右邊一格的字元有沒有在窗內
            - 有，擴張失敗
                更新str位置到窗內重複字元的index + 1上，因為撞到這個重複的值後，再往右幾格這兩個重複的數字都會在窗內，所以str要直接跳過去來避免浪費
            - 沒，擴張成功
                嘗試更新看看nowLength有沒有比maxLength大
        5. 迴圈結束回傳maxLength

## #4_Median of Two Sorted Arrays
###### Related Topics: `Binary Search`
### 目標
給兩個int陣列nums1, nums2求兩陣列合併後的中位數(有序數列中間的數或兩數平均)
### 求解
- 暴力法
    C#可以宣告List，然後用addRange跟sort處理完直接算中位數，在LeetCode上的速度不會太差
- 符合O(log(m+n))的解
    1. nums1跟nums2合併得出的nums3，以中位數的位置切成兩半
    2. nums3的左半邊，會是由nums1用某點切割的左半邊與nums2用某點切割的左半邊組成的
    3. nums3的右半邊同理
    4. nums1[0,1,3] nums2[2,4,5] nums3[0,1,2,3,4,5] 
    5. nums1切點在1跟3之間；nums2在2跟4之間
    6. nums1, nums2的左半邊切點的值都會小於nums1, nums2右半切點的值
    7. 這時nums3左半的連接點會是nums1左半接點與nums2左半接點中較大的那個
    8. nums3右半的連接點會是nums1右半接點與nums2右半接點中較小的那個
    9. nums3數字數量是偶數那中位數就是兩接點的平均，奇數則會是其中一個接點(取決與你實作時左半多一格或右半多一格)
    10. 所以只要找到nums1, nums2的正確切割點這樣就可以求出中位數
    11. 因為切割點組出來的長度是可以求的(nums3.Length/2)，所以可以挑nums1的任一位置去推算nums2這時的切點在哪(nums1是長度較短的陣列，這樣搜尋比較快)
    12. 找切點的方式就是使用二元搜尋，當找到的位置可以符合6.就可以利用7.8.9.得出答案

## #5_Longest Palindromic Substring
###### Related Topics: `Dynamic Programming`、`Manacher's Algorithm`
### 目標
給一個字串s，求出最長的回文(字串左右對稱)subString
### 求解
- 暴力法
    雙迴圈尋遍所有s[i]起點到s[j]終點的substring
- 動態規劃
    1. 問題的最小情況，也就是最短的回文會是單個字元
    2. 問題的擴張，假設有i, j代表字串的頭尾，那從單個字元(i==j)往外擴張(i--, j++)，那s[i]還是會等於s[j]
    3. 所以可以藉由紀錄s[i] ~ s[j]的狀況，遇到s[i-1] ~ s[j+1]時檢查下面的條件來重複利用已經比對過的subString
        - s[i-1] == s[j+1] 
        - s[i]~s[j]是不是回文
    4. 實作上可以用二維的bool陣列來紀錄，比較需要注意的是重複利用的部分是table[i+1, j-1]，所以雙迴圈掃描的那個方向要是可以先處理[i+1, j-1]這個位置的
- Manacher's Algorithm
    1. 中心擴展，以某字元為中心往左右擴張看尋找這個中心能產生的長回文。比如acbcd，以b為中心可以擴張一次得到cbc，然後回文半徑為1，這個半徑之後會用到
    2. 字串預先處理，在字串間(包含頭尾)插入符號，比如abbc→#a#b#b#c#，這樣的用意是偶數回文也可以用中心擴展找到，比如上面的#a#b#b#c#可以藉由最中間的#找到#b#b#這個回文，另一個用意是得到的半徑剛好會是回文的長度(去除符號)
    3. 鏡面特性，其實使用上面的方法就已經能夠解決題目，而這個演算法能比動態規劃還要快的原因就在這裡，下面的回文以c為中心左邊的半徑可以直接的貼到右邊而不用使用中心擴展
        |#|a|#|c|#|b|#|c|#|b|#|c|#|d|#|
        |-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|
        |0|1|0|1|0|3|0|5|0|3|0|1|0|1|0|
        | | | |m| | | |c| | | |i| | |r|
    4. 不過這個特性還是有些限制，某些情況還是得用中心擴展來找半徑。實作上會有四個變數回文的中心c(cneter)、回文的右邊界r(right)、迴圈目前的進度i跟鏡面的m(mirror_i)跟存半徑的陣列r，綜合下面兩點會得出左半邊裡的子回文不能超出c位置回文的左邊界這個條件，也就是m-r[m]>c-r[c]
        1. i+r[m]超過r，因為不能確定r後面的部分能不能湊成回文或者有沒有超出陣列
        2. m, c位置為中心的回文左邊界在同一位置，因為i位置的那個回文可能會超出r
    5. c, r的更新，當目前位置的回文右邊界超出r就把這個位置當作新的c右邊界則是新的r，這是為了讓i保持在r的裡面
    6. 輸出，照上面的流程可以得到所有半徑(原字串回文長度)，而輸出需要知道這個回文在原字串的起點是哪裡，轉換方式是(index - r[index])/2，所以過程中更新最大長度時記得紀錄那個index

## #7_Reverse Integer
###### Related Topics: `Math`
### 目標
輸入一個int回傳反轉後的int，如果超出int則回傳0
### 求解
1. 取得尾數 x%10
2. 消除尾數 x/10
3. 檢查會不會益位
    - 正數，目前累加的值不能超過int.max/10，如果等於int.max/10那這輪的尾數不能大於7
    - 負數，目前累加的值不能小於int.min/10，如果等於int.min/10那這輪的尾數不能小於-8
4. 累加的數乘10在把這輪的尾數加上去

## #8_String to Integer
###### Related Topics: `String`
### 目標
給一個字串str轉換成數字
- 開頭的空白可以接受，欲到正負號或者數字後不行
- 數字間欲到其他字元就回傳目前截到的字串轉數字
- 益位回傳int.max或者int.min
### 求解
1. 第一次迴圈，遇到不是空白跳出，i會是數字起點
2. 檢查字串i是不是已經盡頭，是回傳0
3. 檢查str[i]是不是正負號，是的話i要再加一，然後正負號存起來(sign)
4. 第二次迴圈，遇到非數字跳出，j會是終點
5. 截出要轉換的字串str.subString(i, j - i)
6. 如果截出來的長度是0回傳0
7. try catch嘗試轉換sign+str.subString(i, j - i)
8. 如果catch就是益位，看sign來選擇回傳int.max或int.min