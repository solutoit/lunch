var UserNameEditor = React.createClass({
	render: function() {
		return (
			<form action="/DoLogin" method="post">
				<input type="text" name="email" value="Type your soluto mail address" />
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