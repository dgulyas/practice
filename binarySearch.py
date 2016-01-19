def bSearch(a, target):
	if len(a) == 0:
		return -1
		
	left = 0
	right = len(a) - 1
	
	if a[left] == target:
		return left
	if a[right] == target:
		return right
	
	while left + 1 < right:
		middle = int((right-left)/2) + left
		if a[middle] == target:
			return middle
		if a[middle] > target:
			right = middle
		else:
			left = middle
	return -1


a = []
for i in range(20):
	a.append(i)

for i in range(21):
	print(bSearch(a,i))

print()
print(bSearch([],5) == -1)
print(bSearch([1],1) == 0)
print(bSearch([1],5) == -1)
print(bSearch([1,2],5) == -1)
print(bSearch([1,2],1) == 0)
print(bSearch([1,2],2) == 1)