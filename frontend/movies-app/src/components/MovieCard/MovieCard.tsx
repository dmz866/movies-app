import { Movie } from "../../models";

type TProps = {
    movie: Movie
};

export const MovieCard = ({ movie }: TProps) => {
    return (
        <>
            <p className="text-3xl font-bold my-2">{movie.name}</p>
            <p className="text-xxl font-bold my-2">{movie.description}</p>
            <p className="text-xl font-bold my-2">Actors</p>
            <div className="flex">
                {movie.actors?.map((a, indx) => <span key={`${a.name}-${indx}`}>{a.name}</span>)}
            </div>
        </>
    );
};