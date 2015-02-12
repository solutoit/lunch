var UserNameEditor = React.createClass({
	render: function() {
		return (
			<form action="/Login/DoLogin" method="post" className="w-clearfix">
				<input className="w-input field" type="text" name="name" placeholder="Your user name (in Soluto domain)" />
				<button className="w-button button" type="submit">Login</button>
			</form>
		);
	}
});

var Page = React.createClass({
	render: function() {
		return (
			<div className="w-container container">
				<h1>Soluto Lunchbox</h1>
				<UserNameEditor />
				<p className="subtitle">Where should we eat today?</p>
			</div>
		);
	}
});

React.render(<Page />,document.getElementById('content'));