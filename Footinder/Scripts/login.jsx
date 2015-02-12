var UserNameEditor = React.createClass({
	render: function() {
		return (
			<form action="/Login/DoLogin" method="post">
				<input type="text" name="name"  />
				<button type="submit">Login</button>
			</form>
		);
	}
});

var Page = React.createClass({
	render: function() {
		return (
			<UserNameEditor />
		);
	}
});

React.render(<Page />,document.getElementById('content'));