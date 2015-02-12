var RestaurantView = React.createClass({
	render:function() {
		if(!this.props.restaurant) return <noscript/>;

		return (
		<div className="rest">
			<div className="pic"><img src={this.props.restaurant.LogoUri}/></div>
			<div className="details">
				<div className="title">{this.props.restaurant.Name}</div>
			</div>
		</div>
		);
	}
});

var DecisionButtons = React.createClass({
	decisionHandler:function(decision) {
		this.props.decisionHandler(decision);
	},
	render:function() {
		var onNo = this.decisionHandler.bind(this, false);
		var onYes = this.decisionHandler.bind(this, true);
		return (
			<div className='decision-buttons'>
				<button onClick={onNo}>no</button>
				<button onClick={onYes}>yes</button>
			</div>
		);
	}
});

var App = React.createClass({
	getInitialState: function() {
        $.ajax('/Restaurants', {
            success: function(data) {
                this.setState({restaurants:data, currentRest: 0});
            }.bind(this)
        });
        
        return {currentRest: -1, restaurants: []};
	},
    getCurrentRest: function() {
        if(this.state.currentRest < 0) return undefined;
        return this.state.restaurants[this.state.currentRest];
    },
    decisionHandler: function(decision) {
    	// Update server
		$.post('/api/Vote?id=' + this.getCurrentRest().Id + '&vote=' + decision);

    	var curr = this.state.currentRest;

    	// If finished all restaurants, navigate to grouping page
    	if(curr == this.state.restaurants.length - 1) {
    		window.location.href = '/YourGroup';
    	}

    	this.setState({currentRest: curr + 1});
    },
	render: function() {
		return (
		<div>
			<RestaurantView restaurant={this.getCurrentRest()} />
			<DecisionButtons decisionHandler={this.decisionHandler} />
		</div>
		);
	}
});

React.render(<App />,document.getElementById('content'));