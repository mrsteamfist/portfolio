# gets the index of the found item or None
# assumes the array is sorted
def binary_search(array:list, target) -> int:
  if not array or len(array) == 0:
    return None

  l, r = 0, len(array) - 1
  while l <= r:
    m = l + ((r-l) // 2)
    if array[m] > target:
      r = m -1
    elif array[m] < target:
      l = m+1
    else:
      return m
  return None

test_array = [1,2,3,4,5,65,6345,76687,8234234,990462346234]

print("Run 1: ", binary_search(test_array, 6345))
print("Run 2: ", binary_search(test_array, 1))
print("Run 3: ", binary_search(test_array, 990462346234))
print("Run 4: ", binary_search(test_array, 0))