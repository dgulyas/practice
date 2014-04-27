def bubbleSort(a):
	for i in range(len(a) - 1):
		#print "pass:",i
		x = 0
		while x < len(a) - i - 1:
			#print "compare:",x, ",", x+1
			if a[x] > a[x+1]:
				tmp = a[x]
				a[x] = a[x+1]
				a[x+1] = tmp
			x = x+1
	return a 
	
a = [9,8,7,6,5,4]
bubbleSort(a)
print a

a = [1]
bubbleSort(a)
print a

a = []
bubbleSort(a)
print a