import { useState } from 'react';
import { ClipLoader } from 'react-spinners';
import { MovieCard } from '../../components';
import { useMoviesPage } from './useMoviesPage';

export const MoviesPage = () => {
    const { isLoading, handleSearch, noMovieFound, movies } = useMoviesPage();
    const [searchValue, setSearchValue] = useState('');
    const handleInput = (e: any) => {
        const fieldValue = e.nativeEvent.target.value;
        setSearchValue(fieldValue);
    }

    return (
        <div className="flex-row">
            <div className="w-[800px] mx-auto justify-center flex mt-10">
                <div className="w-full">
                    <p className="text-3xl font-bold my-2">Movies App</p>
                    <div className="mx-auto justify-center flex-row p-4">
                        <div className="flex justify-items-center content-center gap-x-4 mt-2">
                            <p className="font-semibold">Search By Name:</p>
                            <input name='searchValue' type="text" className="text-black w-2/4 py-1 px-2 border rounded-lg" onChange={handleInput} />
                            <button className="px-2 mx-2 border rounded-lg bg-green-200 py-1" onClick={() => handleSearch(searchValue)}>Search</button>
                        </div>
                    </div>
                    <div className="flex justify-center">
                        {
                            isLoading &&
                            <ClipLoader
                                loading={isLoading}
                                size={150}
                                aria-label="Loading Spinner"
                                data-testid="loader"
                            />
                        }
                    </div>
                    <div className="p-3 flex flex-wrap">
                        {noMovieFound && <p>No Movies found</p>}
                        {movies?.map((p) => {
                            return <MovieCard key={p.name} movie={p} />
                        })}
                    </div>
                </div>
            </div>
        </div>
    );
};