var RestaurantView = React.createClass({
	render:function() {
		return (
		<div class='rest'>
			<div class='pic'><img src='{this.props.restaurant.LogoUri}/><div>
			<div class='details'>
				<div class='title'>{this.props.restaurant.Name}</div>
			</div>
		</div>
		);
	}
});

var App = React.createClass({
	getInitialState: function() {
        $.ajax('/Restaurants', {
            success: function(data) {
                this.setState({restaurants:data});
            }
        });
        
        return {currentRest: -1, restaurants: []};
	},
    getCurrentRest: function() {
        if(this.state.currentRest < 0) return undefined;
        return this.state.restaurants[this.state.currentRest];
    },
	render: function() {
		return (
		<div>
			<RestaurantView restaurant={getCurrentRest()} />
		</div>
		);
	}
});

var rests = '[{"Id":"78e106ff-56a9-4983-b22f-1f6976782408","Name":"פטרוזיליה","Distance":null,"LogoUri":null},{"Id":"5a16c13d-7631-4c74-b186-d6b1354fa2db","Name":"רוסטיקו","Distance":null,"LogoUri":null},{"Id":"d3ad0e6f-e048-4709-85a1-e89f3627515e","Name":"סאלם בומביי","Distance":null,"LogoUri":null}]';

React.render(<App />,document.getElementById('content'));