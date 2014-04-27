class node:
	def __init__(self, inData):
		self.data = inData
		self.next = None
		self.prev = None
		
class dLinkedList:
	def __init__(self):
		self.head = None
		self.tail = None
	
	#add a node to the list
	def add(self, data):
		if self.head == None:
			self.head = node(data)
			self.tail = self.head
		else:
			self.tail.next = node(data)
			self.tail.next.prev = self.tail
			self.tail = self.tail.next
	
	#remove a node from the list
	def remove(self, target):
		if self.head:
			pointer = self.head
		else:
			return #there are no elements in the list
		
		while pointer.data != target: #find the target in the list
			if pointer.next == None:
				return #the target is not in the list
			pointer = pointer.next
		
		#pointer should now point at the target node
		
		if self.head == pointer: #if target is the head, change head pointer
			self.head = pointer.next
		
		if self.tail == pointer: #if target is the tail, change tail pointer
			self.tail = pointer.prev
			
		if pointer.prev: #change the pointers
			pointer.prev.next = pointer.next
		if pointer.next:
			pointer.next.prev = pointer.prev
	
	#print the list starting at the front
	def pForward(self):
		pointer = self.head
		while pointer:
			print pointer.data, 
			pointer = pointer.next
		print ""
	
	#print the list starting at the back
	def pBackward(self):
		pointer = self.tail
		while pointer:
			print pointer.data, 
			pointer = pointer.prev
		print ""
	
	#returns true if the list contains the target value, otherwise false
	def contains(self, target):
		pointer = self.head
		while pointer:
			if pointer.data == target:
				return True
			pointer = pointer.next
		return False
	
	#returns the size of the list
	def size(self):
		n = 0
		pointer = self.head
		while pointer:
			n = n + 1
			pointer = pointer.next
		return n

		
list = dLinkedList()
for i in range(8):
	list.add(i) #test add

list.pForward() #test pForward
list.pBackward()#test pBackward
print"remove 4"
list.remove(4) #test remove and its corner cases
list.pForward()
list.pBackward()
print"remove 0"
list.remove(0)
list.pForward()
list.pBackward()
print"remove 7"
list.remove(7)
list.pForward()
list.pBackward()
print"remove 9"
list.remove(9)
list.pForward()
list.pBackward()

print "contains 1:", list.contains(1) #test contains and its corner cases
print "contains 6:", list.contains(6)
print "contains 3:", list.contains(3)
print "contains 9:", list.contains(9)

print "size:",list.size() #test size

list.remove(1) #empty the list
list.remove(2)
list.remove(3)
list.remove(5)
list.remove(6)
print "remove all nodes"
print "size:",list.size() #test to see if it's empty