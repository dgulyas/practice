function UserListTable({users}) {
	const userList = users.map((userInstance, index) => {
		return ( <User user={userInstance}/> );
	});

	return(
		<ol>
		  	{userList}
		</ol>
	);
}

function User({user}){
	return(
		<li key={user}>
			FirstName: {user.FirstName}
		</li>
	);
}


export default UserListTable;