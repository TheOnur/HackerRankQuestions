def shifted_array(arr, k):
    shifted = []
    n = len(arr)
    index = 0
    
    for item in arr:
        new_index = (index + k) % n
        shifted.insert(new_index , item)
        index = index + 1

    return shifted

arr = [3, 8, 9, 7, 6]
k = 3
print(shifted_array(arr, k))