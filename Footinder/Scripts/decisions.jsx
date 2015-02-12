var RestaurantView = React.createClass({
	render:function() {
		if(!this.props.restaurant) return <noscript/>;

		return (
		<div className="restaurant">
			<img className="logo" src={this.props.restaurant.LogoUri}/>
			<div className="about_palce">
				<strong>{this.props.restaurant.Name} <br/></strong>
				Address:{this.props.restaurant.Address} <br/>
				Distance:{this.props.restaurant.DistanceMeters} Meters <br/>
				Walking time:{this.props.restaurant.WalkingTimeMinutes} minutes <br/>
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
				<div className="no_icon" onClick={onNo}></div>
				<div className="yes_icon" onClick={onYes}></div>
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
		<div className="w-container container">
			<h1>Soluto Lunchbox</h1>
			<p className="subtitle">Where should we eat today?</p>
			<RestaurantView restaurant={this.getCurrentRest()} />
			<DecisionButtons decisionHandler={this.decisionHandler} />
		</div>
		);
	}
});

React.render(<App />,document.getElementById('content'));