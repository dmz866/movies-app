import { Link } from "react-router";

type TProps = {
    links: { name: string, path: string }[];
};

export const Header = ({ links }: TProps) => {
    return (
        <div className="flex">
            <Link className="text-white w-full" to='/'>
                <p className="text-3xl font-bold text-white ml-4 mt-4">Movies App</p>
            </Link>
            <div className="w-full flex justify-end gap-x-8 mx-4 mt-4 font-bold">
                {
                    links.map(link => (
                        <Link className="hover:underline text-white" key={link.name} to={link.path}>{link.name}</Link>
                    ))
                }
            </div>
        </div>
    );
}