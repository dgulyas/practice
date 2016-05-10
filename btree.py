class node:
	def __init__(self, inData):
		self.data = inData
		self.left = None
		self.right = None
		
class bTree:
	def __init__(self):
		self.root = None
	
	def insertNode(self, currentNode, newNode):
		if currentNode.data > newNode.data:
			if currentNode.left is None:
				currentNode.left = newNode
			else:
				self.insertNode(currentNode.left, newNode)
		else:
			if currentNode.right is None:
				currentNode.right = newNode
			else:
				self.insertNode(currentNode.right, newNode)
	
	def insert(self, data):
		newNode = node(data)
		if self.root is None:
			self.root = newNode
		else:
			self.insertNode(self.root, newNode)
	
	def deptFirstPrintNode(self, node):
		print(node.data)
		if node.left is not None:
			self.deptFirstPrintNode(node.left)
		if node.right is not None:
			self.deptFirstPrintNode(node.right)
	
	def depthFirstPrint(self):
		self.deptFirstPrintNode(self.root)
	
	def transverseNodesDoing(self, node, function):
		function(node)
		if node.left is not None:
			self.transverseNodesDoing(node.left, function)
		if node.right is not None:
			self.transverseNodesDoing(node.right, function)
	
	#def bfPrint(self):
		#bfPrintNode(self.root)
	
	#def bfPrintNode(self, node):

btree = bTree()
btree.insert(4)
btree.insert(2)
btree.insert(1)
btree.insert(3)
btree.insert(6)
btree.insert(5)
btree.insert(7)
print("normal print function:")
btree.depthFirstPrint()
print("lambda print function")
btree.transverseNodesDoing(btree.root, lambda node:print(node.data))
findLambda = lambda node: if node.data is None:
	return False
if node.data = 
print(btree.transverseNodesDoing btree.root, lambda node: if