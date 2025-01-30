import { ActorContext } from "./modules/movies/context/ActorContext/ActorContext";
import { useActorContext } from "./modules/movies/context/ActorContext/useActorContext";
import { MovieContext } from "./modules/movies/context/MovieContext/MovieContext";
import { useMovieContext } from "./modules/movies/context/MovieContext/useMovieContext";
import { NavigationRouter } from "./modules/movies/routing";

const App = () => {
    const { contextValue: movieContextValue } = useMovieContext();
    const { contextValue: actorContextValue } = useActorContext();

    return (
        <MovieContext.Provider value={movieContextValue}>
            <ActorContext.Provider value={actorContextValue}>
                <NavigationRouter />
            </ActorContext.Provider>
        </MovieContext.Provider>
    );
}

export default App;