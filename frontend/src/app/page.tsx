// src/app/page.tsx
export default function HomePage() {
  return (
    <div className="grid grid-cols-4 gap-4 mt-4">
      <div className="bg-[#00AE8D] text-white p-6 rounded-2xl col-span-2 row-span-2 shadow-lg">
        <h2 className="text-2xl font-semibold">Grande tuile</h2>
        <p className="text-sm mt-2">Contenu principal</p>
      </div>

      <div className="bg-[#e6007e] text-white p-4 rounded-xl col-span-1 shadow-md">
        <h3 className="font-medium">Tuile moyenne</h3>
        <p className="text-xs">Autre contenu</p>
      </div>

      <div className="bg-black text-white p-2 rounded-lg col-span-1 row-span-1 shadow-sm text-center">
        <span className="text-xs">Petite tuile</span>
      </div>

      <div className="bg-white border border-gray-300 p-4 rounded-xl col-span-1 row-span-1">
        <p className="text-sm">Tuile neutre</p>
      </div>
    </div>
  )
}

