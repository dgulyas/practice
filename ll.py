class node:
	def __init__(self, inData):
		self.data = inData
		self.next = None

class linkedList:
	def __init__(self):
		self.head = None
		self.tail = None
	
	def contains(self, target):
		pointer = self.head
		while pointer:
			if pointer.data == target:
				return True
			pointer = pointer.next
		return False
	
	def add(self, data):
		if self.head == None:
			self.head = node(data)
			self.tail = self.head
		else:
			self.tail.next = node(data)
			self.tail = self.tail.next
	
	def remove(self, target):
		if self.head:
			if self.head.data == target:
				self.head = self.head.next
				return
		
		pointer = self.head

		while pointer.next:
			if pointer.next.data == target:
				pointer.next = pointer.next.next
				return
				
			pointer = pointer.next
				
		
	def printList(self):
		pointer = self.head
		while pointer:
			print pointer.data, 
			pointer = pointer.next
		print ""
	

list = linkedList()
for i in range(8):
	list.add(i)

list.printList()
list.remove(4)
list.printList()
list.remove(7)
list.printList()
list.remove(0)
list.printList()
list.remove(20)
list.printList()
print "contains 1:",list.contains(1)
print "contains 6:",list.contains(6)
print "contains 3:",list.contains(3)
print "contains 4:",list.contains(4)